var gulp = require('gulp'),
    gutil = require('gulp-util'),
    plugins = require('gulp-load-plugins')(),
    handleErrors = require('./build/handleErrors.js');
;

gulp.task('default', ['watch']);

gulp.task('less', function () {
    return gulp.src('less/app.less')
            .pipe(plugins.sourcemaps.init())
            .pipe(plugins.less())
            .on('error', handleErrors)
            .pipe(plugins.sourcemaps.write())
            .pipe(gulp.dest('./Content'));

});

gulp.task('watch', ['less'], function () {
    gulp.watch('less/*.less', ['less']);
});