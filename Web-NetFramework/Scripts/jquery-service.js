/**
 * This JavaScript Library is for requesting the common JSON result.
 * 
 * 
 * 
 * 
 * 
 * 
 * */
; (function () {
    if (window.$ == undefined) {
        console.error("please add the jquery first");
    }

    /**
     * 发送邮件
     * @param {any} toAddress
     */
    var _sendMail = function (toAddress) {
        if (!toAddress) {
            alert("Please add an Email Address");
            return;
        }
        var data = {};
        $.ajax({
            url: '/Email/SendAsync',
            data: {
                 toAddress
            }
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }

    var _myMail = function () {
        $.ajax({
            url: '/Email/MeAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 所有用户
     * @param show If false, it will not show the result in the element with '.info' class
     * */
    var _users = function () {
        var show = true;
        $.ajax({
            url: '/User/UsersAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 显示我的信息
     * */
    var _meInfo = function () {
        $.ajax({
            url: '/User/MeAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 显示数据
     * @param {any} data
     */
    var _showData = function (data) {
        if ($('.info')) {
            $('.info').text(JSON.stringify(data,2));
        }
    }
    var _ajaxHelper = {
        sendMail: _sendMail,
        myMail:_myMail,
        users: _users,
        me: _meInfo,
    };


    if (!window.ajaxHelper) {
        window.ajaxHelper = { };
    }
    Object.assign(window.ajaxHelper, _ajaxHelper);
})();