////获取url参数值
//function GetRequest(url) {
//	var theRequest = new Object();
//	if(url.indexOf("?") != -1) {
//		var str = url.substr(1);
//		strs = str.split("&");
//		for(var i = 0; i < strs.length; i++) {
//			theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
//		}
//	}
//	return theRequest;
//}

//获取url参数值
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

/********************************************************/
//键值对
function KeyValue(key, value) {
	this.key = key;
	this.value = value;
}

//字符串排序
var by = function (name) {
	return function(o, p) {
		var a, b;
		if(typeof o === "object" && typeof p === "object" && o && p) {
			a = o[name];
			b = p[name];
			if(a === b) {
				return 0;
			}
			if(typeof a === typeof b) {
				return a < b ? -1 : 1;
			}
			return typeof a < typeof b ? -1 : 1;
		} else {
			throw("error");
		}
	}
}

//获取签名
function GetSign(objectList) {

	objectList.sort(by('key'));
    var strSet = "";
	for(var i = 0; i < objectList.length; i++) {
		strSet += objectList[i].key + objectList[i].value;
	}

	strSet += Sys.APP_TOKEN

	return hex_md5(strSet);
}