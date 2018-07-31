var HTTP_IP_URL = "../../..";
//发布评价
var HTTP_RELEASE_EVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/ReleaseEvaluate.aspx";
//获取待评价列表URL
var HTTP_GET_TOEVALUATE_LIST_URL = HTTP_IP_URL + "/Service/Evaluate/GetToEvaluateList.aspx";
//获取我的评价列表URL
var HTTP_GET_MYEVALUATE_LIST_URL = HTTP_IP_URL + "/Service/Evaluate/GetMyEvaluateList.aspx";
//获取评价详情URL
var HTTP_GET_EVALUATE_DETAIL_URL = HTTP_IP_URL + "/Service/Evaluate/GetEvaluateDetail.aspx";
//提交反馈URL
var HTTP_SUBMIT_FEEDBACK_URL = HTTP_IP_URL + "/Service/Complain/SubmitFeedback.aspx";
//获取我的反馈列表URL
var HTTP_GET_MYFEEDBACK_LIST_URL = HTTP_IP_URL + "/Service/Complain/GetMyFeedbackList.aspx";
//获取反馈详情URL
var HTTP_GET_FEEDBACK_DETAIL_URL = HTTP_IP_URL + "/Service/Complain/GetFeedbackDetail.aspx";
//删除我的评估URL
var HTTP_DELETE_MYEVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/DeleteMyEvaluate.aspx";
//删除我的反馈URL
var HTTP_DELETE_MYFEEDBACK_URL = HTTP_IP_URL + "/Service/Complain/DeleteMyFeedback.aspx";
//删除待评估URL
var HTTP_DELETE_TOEVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/DeleteToEvaluate.aspx";
//获取上一个已评价URL
var HTTP_GET_LAST_EVALUATED_URL = HTTP_IP_URL + "/Service/Evaluate/GetLastEvaluated.aspx";
//发布评价(处理结果)
var HTTP_RELEASE_EVALUATE_HANDLED_URL = HTTP_IP_URL + "/Service/Complain/ReleaseEvaluate_Handled.aspx";
//获取我的评价（处理结果）URL
var HTTP_GET_MYEVALUATE_HANDLED_URL = HTTP_IP_URL + "/Service/Complain/GetMyEvaluate_Handled.aspx";

//提交问题URL
var HTTP_SUBMIT_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/SubmitProblem.aspx";
//获取我的问题列表URL
var HTTP_GET_MYPROBLEM_LIST_URL = HTTP_IP_URL + "/Service/Problem/GetMyProblemList.aspx";
//获取问题详情URL
var HTTP_GET_PROBLEM_DETAIL_URL = HTTP_IP_URL + "/Service/Problem/GetProblemDetail.aspx";
//删除我的问题URL
var HTTP_DELETE_MYPROBLEM_URL = HTTP_IP_URL + "/Service/Problem/DeleteMyFeedback.aspx";
//发布评价(问题处理结果)URL
var HTTP_RELEASE_EVALUATE_HANDLED_OF_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/ReleaseEvaluate_Handled.aspx";
//获取我的评价（问题处理结果）URL
var HTTP_GET_MYEVALUATE_HANDLED_OF_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/GetMyEvaluate_Handled_Of_Problem.aspx";

//发布评价URL
function GetURL_ReleseEvaluate() {
	return HTTP_RELEASE_EVALUATE_URL;
}
//获取待评价列表URL
function GetURL_GetToEvaluateList() {
    return HTTP_GET_TOEVALUATE_LIST_URL;
}
//获取我的评价列表URL
function GetURL_GetMyEvaluateList() {
    return HTTP_GET_MYEVALUATE_LIST_URL;
}
//获取评价详情URL
function GetURL_GetEvaluateDetail() {
    return HTTP_GET_EVALUATE_DETAIL_URL;
}
//提交反馈URL
function GetURL_SubmitFeedback() {
    return HTTP_SUBMIT_FEEDBACK_URL;
}
//获取我的反馈列表URL
function GetURL_GetMyFeedbackList() {
    return HTTP_GET_MYFEEDBACK_LIST_URL;
}
//获取反馈详情URL
function GetURL_GetFeedbackDetail() {
    return HTTP_GET_FEEDBACK_DETAIL_URL;
}
//删除我的反馈URL
function GetURL_DeleteMyFeedback() {
    return HTTP_DELETE_MYFEEDBACK_URL;
}
//删除我的评估URL
function GetURL_DeleteMyEvaluate() {
    return HTTP_DELETE_MYEVALUATE_URL;
}
//删除待评估URL
function GetURL_DeleteToEvaluate() {
    return HTTP_DELETE_TOEVALUATE_URL;
}
//获取上一个已评价URL
function GetURL_GetLastEvaluated() {
    return HTTP_GET_LAST_EVALUATED_URL;
}
//发布评价(处理结果)
function GetURL_ReleseEvaluate_Handled() {
    return HTTP_RELEASE_EVALUATE_HANDLED_URL;
}
//获取我的评价（处理结果）URL
function GetURL_GetMyEvaluate_Handled() {
    return HTTP_GET_MYEVALUATE_HANDLED_URL;
}


//提交问题URL
function GetURL_SubmitProblem() {
    return HTTP_SUBMIT_PROBLEM_URL;
}
//获取我的问题列表URL
function GetURL_GetMyProblemList() {
    return HTTP_GET_MYPROBLEM_LIST_URL;
}
//获取问题详情URL
function GetURL_GetProblemDetail() {
    return HTTP_GET_PROBLEM_DETAIL_URL;
}
//删除我的问题URL
function GetURL_DeleteMyProblem() {
    return HTTP_DELETE_MYPROBLEM_URL;
}
//发布评价(问题处理结果)URL
function GetURL_ReleseEvaluate_Handled_Of_Problem() {
    return HTTP_RELEASE_EVALUATE_HANDLED_OF_PROBLEM_URL;
}
//获取我的评价（问题处理结果）URL
function GetURL_GetMyEvaluate_Handled_Of_Problem() {
    return HTTP_GET_MYEVALUATE_HANDLED_OF_PROBLEM_URL;
}










