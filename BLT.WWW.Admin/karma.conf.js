// Karma configuration

module.exports = function (config) {
    config.set({
        basePath: '',
        autoWatchBatchDelay: 2000,
        // frameworks to use
        frameworks: ['jasmine', 'browserify'],


        files: [
            '**/*.spec.js'
        ],

        exclude: [],
        reporters: ['mocha'],
        port: 9876,
        runnerPort: 9100,

        colors: true,
        logLevel: config.LOG_ERROR,
        autoWatch: true,
        browsers: ['Chrome'],
        captureTimeout: 60000,
        singleRun: false,



        browserify: {
            basedir: './',
            debug: true,
            transform: ['brfs']
        },
        preprocessors: {
            '**/*.spec.js': ['browserify']
        },
        plugins: [
            'karma-chrome-launcher',
            'karma-jasmine',
            'karma-bro',
            'karma-mocha-reporter'
        ]


    });
};