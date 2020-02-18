var loginController = {
    init: function () {
        this.registerEvents();
    },
    registerEvents: function () {
        $('#btnLogin').off('click').on('click', function (e) {
            e.preventDefault();
            loginController.login();
        })
    },
    login: function () {
        var username = $('#txtUsername').val();
        var password = $('#txtPassword').val();
        var LoginViewModel = {
            UserName: username,
            Password: password,
            RememberMe: false
        }
        $.ajax({
            url: '/Login/LoginAjax',
            type: 'Post',
            data: {
                model: JSON.stringify(LoginViewModel)
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    console.log(res.user);
                    var role = []  
                    for (var i = 0; i < res.user.Roles.length; i++) {
                        role.push(res.user.Roles[i].RoleId);
                    }
                    if (role.includes('Ad'))
                        location.href = '/Admin/Home/Index';
                    else {
                        $.ajax({
                            url: '/Login/LogOutAjax',
                            type: 'Post',
                            dataType: 'json',
                            success: function (response) {
                                if (response)
                                    location.href = '/';
                            }
                        });
                        alert("Bạn không có quền Admin để vào trang quản trị");
                    }     
                }
                else {
                    alert(res.message);
                }
            }
        })
    }
}

loginController.init();