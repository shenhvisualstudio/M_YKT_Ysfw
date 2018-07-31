//获取url参数值
function GetRequest(url) { 
    var theRequest = new Object(); 
    if (url.indexOf("?") != -1) { 
       var str = url.substr(1); 
       strs = str.split("&"); 
       for(var i = 0; i < strs.length; i ++) { 
           theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]); 
       } 
    } 
    return theRequest; 
}


//自定义弹框  
function Toast(msg, duration) {
    duration = isNaN(duration) ? 3000 : duration;
    var m = document.createElement('div');
    m.innerHTML = msg;
    m.style.cssText = "font-size: 0.6rem; width:20%; min-width:100px; background:black; color: white; height:30px; line-height:30px; text-align:center; border-radius:8px; position:fixed; top:80%; left:35%; z-index:999999;";
    document.body.appendChild(m);
    setTimeout(function () {
        var d = 0.5;
        m.style.webkitTransition = '-webkit-transform ' + d + 's ease-in, opacity ' + d + 's ease-in';
        m.style.opacity = '0';
        setTimeout(function () { document.body.removeChild(m) }, d * 1000);
    }, duration);
}


