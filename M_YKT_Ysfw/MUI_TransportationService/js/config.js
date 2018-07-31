/*
 * 系统配置
 */
var Sys = {
	/*
	 * 应用编码
	 */
	APP_CODE : "ZSFW",
	/*
	 * 应用口令 
	 */
	APP_TOKEN : "59EBE342A9A5A0B6E053A8640169A0B6",
}

/*
 * URL
 */
var HTTP_IP_URL = "http://www.boea.cn/M_YKT_Ysfw";
var Url = {
	//发布评价URL
	HTTP_RELEASE_EVALUATE_URL: HTTP_IP_URL + "/Service/Evaluate/ReleaseEvaluate.aspx",
	//获取待评价列表URL
	HTTP_GET_TOEVALUATE_LIST_URL: HTTP_IP_URL + "/Service/Evaluate/GetToEvaluateList.aspx",
	//获取我的评价列表URL
	HTTP_GET_MYEVALUATE_LIST_URL: HTTP_IP_URL + "/Service/Evaluate/GetMyEvaluateList.aspx",
	//获取评价详情URL
	HTTP_GET_EVALUATE_DETAIL_URL: HTTP_IP_URL + "/Service/Evaluate/GetEvaluateDetail.aspx",
	//删除我的评估URL
	HTTP_DELETE_MYEVALUATE_URL: HTTP_IP_URL + "/Service/Evaluate/DeleteMyEvaluate.aspx",
	//删除待评估URL
	HTTP_DELETE_TOEVALUATE_URL: HTTP_IP_URL + "/Service/Evaluate/DeleteToEvaluate.aspx",
	//获取历史评价列表URL
	HTTP_GET_HISTORYEVALUATE_LIST_URL: HTTP_IP_URL + "/Service/Evaluate/GetHistoryEvaluateList.aspx",

	//提交问题URL
	HTTP_SUBMIT_PROBLEM_URL: HTTP_IP_URL + "/Service/Problem/SubmitProblem.aspx",
	//获取我的问题列表URL
	HTTP_GET_MYPROBLEM_LIST_URL: HTTP_IP_URL + "/Service/Problem/GetMyProblemList.aspx",
	//获取问题详情URL
	HTTP_GET_PROBLEM_DETAIL_URL: HTTP_IP_URL + "/Service/Problem/GetProblemDetail.aspx",
	//删除我的问题URL
	HTTP_DELETE_MYPROBLEM_URL: HTTP_IP_URL + "/Service/Problem/DeleteMyProblem.aspx",
	//发布评价(问题处理结果)URL
	HTTP_RELEASE_EVALUATE_HANDLED_OF_PROBLEM_URL: HTTP_IP_URL + "/Service/Problem/ReleaseEvaluate_Handled_Of_Problem.aspx",
	//获取我的评价（问题处理结果）URL
	HTTP_GET_MYEVALUATE_HANDLED_OF_PROBLEM_URL: HTTP_IP_URL + "/Service/Problem/GetMyEvaluate_Handled_Of_Problem.aspx",
	//获取历史问题列表URL
	HTTP_GET_HISTORYPROBLEM_LIST_URL: HTTP_IP_URL + "/Service/Problem/GetHistoryProblemList.aspx",

	//提交投诉URL
	HTTP_SUBMIT_COMPLAIN_URL: HTTP_IP_URL + "/Service/Complain/SubmitComplain.aspx",
	//获取我的投诉列表URL
	HTTP_GET_MYCOMPLAIN_LIST_URL: HTTP_IP_URL + "/Service/Complain/GetMyComplainList.aspx",
	//获取投诉详情URL
	HTTP_GET_COMPLAIN_DETAIL_URL: HTTP_IP_URL + "/Service/Complain/GetComplainDetail.aspx",
	//删除我的投诉URL
	HTTP_DELETE_MYCOMPLAIN_URL: HTTP_IP_URL + "/Service/Complain/DeleteMyComplain.aspx",
	//发布评价(投诉处理结果)URL
	HTTP_RELEASE_EVALUATE_HANDLED_OF_COMPLAIN_URL: HTTP_IP_URL + "/Service/Complain/ReleaseEvaluate_Handled_Of_Complain.aspx",
	//获取我的评价（投诉处理结果）URL
	HTTP_GET_MYEVALUATE_HANDLED_OF_COMPLAIN_URL: HTTP_IP_URL + "/Service/Complain/GetMyEvaluate_Handled_Of_Complain.aspx",
	//获取历史投诉列表URL
	HTTP_GET_HISTORYCOMPLAIN_LIST_URL: HTTP_IP_URL + "/Service/Complain/GetHistoryComplainList.aspx",
}
