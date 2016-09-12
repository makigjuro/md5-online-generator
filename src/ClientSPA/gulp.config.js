module.exports = function () {
    var temp = './.tmp/';

    var config = {
        temp: temp,
        alljs: [
            './js/**/*.js',
            './*.js'
        ],
        client : '',
        index: 'index.html',
        less: './styles/site.less',
        css: temp + 'site.css',
        js: [
             './js/app.js',
            './js/**/*.js'
        ],
        bower: {
            json: require('./bower.json'),
            directory: './bower_components/',
            ignorePath: './'
        }
    };

    config.getWiredepDefaultOptions = function() {
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
            exclude: "gulp"
        };

        return options;
    };
    
    return config;
};