var gulp = require('gulp');
var config = require('./gulp.config')();
var args = require('yargs').args;
var del = require('del');

var $ = require('gulp-load-plugins')({lazy : true});

gulp.task('vet', function () {
    log('Start with analysing js code');
    
    return gulp
        .src(config.alljs)   
        .pipe($.jscs())
        .pipe($.jshint())
        .pipe($.jshint.reporter('jshint-stylish', {verbose: true}))
        .pipe($.jshint.reporter('fail'));
});

gulp.task('styles', function () {
    log('Compile Less to CSS');
    
    return gulp
        .src(config.less)
        .pipe($.plumber())
        .pipe($.less())
        .pipe($.autoprefixer({browsers : ['last 2 versions', '> 5%']}))
        .pipe(gulp.dest(config.temp));
});

gulp.task('clean-styles', function (doneCallback){
    var files = config.temp + '**/*.css';
    clean(files, doneCallback);

    log('Clean completed');
});

gulp.task("wiredep", function() {
    var options = config.getWiredepDefaultOptions();
    var wiredep = require('wiredep').stream;

    return gulp
        .src(config.index)
        .pipe(wiredep(options))
        .pipe($.inject(gulp.src(config.js)))
        .pipe(gulp.dest(config.client));
});

gulp.task('less-watcher', function() {
    gulp.watch([config.less], ['styles']);
});

//// helper functions

function log(msg) {
    if(typeof(msg) === 'object'){
        for(var item in msg){
            if(msg.hasOwnProperty(item)){
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else{
        $.util.log($.util.colors.blue(msg));
    }
}

function clean(path, doneCallback) {
    log('Cleaning:' + $.util.colors.blue(path));
    del(path, doneCallback);
}