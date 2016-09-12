module.exports = function () {
    var config = {
        temp: './.tmp/',
        alljs: [
            './js/**/*.js',
            './*.js'
        ],
        client : '',
        index: 'index.html',
        less: './styles/site.less',
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