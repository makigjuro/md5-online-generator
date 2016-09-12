module.exports = function () {
    var config = {
        temp: './.tmp/',
        alljs: [
            './js/**/*.js',
            './*.js'
        ],
        
        less: './styles/site.less'        
    };
    
    return config;
};