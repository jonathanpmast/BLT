var path = require('path');
var gulp = require('gulp');
var browserify = require('browserify');
var concat = require('gulp-concat');
var transform = require('vinyl-transform');
var source = require('vinyl-source-stream');
var browserSync = require('browser-sync');
var handleErrors = require('./gulpscripts/handleErrors.js');
var minifyCSS = require('gulp-minify-css');
var watchify = require('watchify');
var inject = require('gulp-inject');
var rename = require('gulp-rename');
var concatcss = require('gulp-concat-css');

var config = {
    main: './main.js',
    htmlSrc: './html',
    cssSrc: './css',
    templates: './templates',
    out: './dist'
};

function buildBrowserifyBundle(watch, mainFile) {
    var b = browserify({
        cache: {},
        packageCache: {},
        fullPaths: true,
        debug: true
    });
    if (watch) {
        b = watchify(b);
        b.on('update', function () {
            doBundle(b).
            pipe(browserSync.reload({ stream: true }));
        });
    }

    b.add(mainFile);
    doBundle(b);
};

function doBundle(b) {
    return b.bundle()
        .on('error', handleErrors)
        .pipe(source('main.js'))
        .pipe(gulp.dest(config.out));
}

gulp.task('html', function () {
    return gulp.src(config.htmlSrc + '/**')
    .pipe(gulp.dest(config.out))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('css', function () {
    return gulp.src(['./node_modules/bootstrap/dist/css/bootstrap.css',
                     './node_modules/bootstrap/dist/css/bootstrap-theme.css',
                     config.cssSrc + '/*.css'])
        .pipe(concatcss('app.css'))
        .pipe(minifyCSS({ keepBreaks: true }))
        .pipe(gulp.dest(config.out));
});

gulp.task('browserSync', function () {
    browserSync({
        server: {
            // Serve up our build folder
            baseDir: config.out
        }
    });
});

gulp.task('templates', function () {
    return gulp.src(config.templates + '/ko_templates.tmpl.js')
        .pipe(inject(gulp.src(config.templates + '/**/*.tmpl.html'), {
            starttag: '//-begin template injection',
            endtag: '//-end template injection',
            transform: function (filePath, file, i, length, target) {
                var name = file.relative.substr(0, file.relative.indexOf(".tmpl.html"));
                var contents = file.contents.toString('utf8').replace(/"/g, "\\x22").
                      replace(/(\r\n|\n|\r)/gm, "");
                var str = 'ko.templates["' + name + '"] = \'' + contents + "';";
                return str;
            }
        }))
        .pipe(rename('ko_templates.js'))
        .pipe(gulp.dest('./'));
});

gulp.task('js', function () {
    buildBrowserifyBundle(false, config.main);
});

gulp.task('watchify', function () {
    buildBrowserifyBundle(true, config.main);
});

gulp.task('watch', ['browserSync', 'watchify'], function () {
    gulp.watch(config.cssSrc + '/*.css', ['css']);
    gulp.watch(config.htmlSrc + '/**', ['html']);
    gulp.watch(config.templates + '/**', ['templates'])
});

gulp.task('default', ['css', 'html', 'templates', 'watch']);