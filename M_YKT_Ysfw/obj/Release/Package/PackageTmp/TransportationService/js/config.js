var HTTP_IP_URL = "../../..";
//��������
var HTTP_RELEASE_EVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/ReleaseEvaluate.aspx";
//��ȡ�������б�URL
var HTTP_GET_TOEVALUATE_LIST_URL = HTTP_IP_URL + "/Service/Evaluate/GetToEvaluateList.aspx";
//��ȡ�ҵ������б�URL
var HTTP_GET_MYEVALUATE_LIST_URL = HTTP_IP_URL + "/Service/Evaluate/GetMyEvaluateList.aspx";
//��ȡ��������URL
var HTTP_GET_EVALUATE_DETAIL_URL = HTTP_IP_URL + "/Service/Evaluate/GetEvaluateDetail.aspx";
//�ύ����URL
var HTTP_SUBMIT_FEEDBACK_URL = HTTP_IP_URL + "/Service/Complain/SubmitFeedback.aspx";
//��ȡ�ҵķ����б�URL
var HTTP_GET_MYFEEDBACK_LIST_URL = HTTP_IP_URL + "/Service/Complain/GetMyFeedbackList.aspx";
//��ȡ��������URL
var HTTP_GET_FEEDBACK_DETAIL_URL = HTTP_IP_URL + "/Service/Complain/GetFeedbackDetail.aspx";
//ɾ���ҵ�����URL
var HTTP_DELETE_MYEVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/DeleteMyEvaluate.aspx";
//ɾ���ҵķ���URL
var HTTP_DELETE_MYFEEDBACK_URL = HTTP_IP_URL + "/Service/Complain/DeleteMyFeedback.aspx";
//ɾ��������URL
var HTTP_DELETE_TOEVALUATE_URL = HTTP_IP_URL + "/Service/Evaluate/DeleteToEvaluate.aspx";
//��ȡ��һ��������URL
var HTTP_GET_LAST_EVALUATED_URL = HTTP_IP_URL + "/Service/Evaluate/GetLastEvaluated.aspx";
//��������(������)
var HTTP_RELEASE_EVALUATE_HANDLED_URL = HTTP_IP_URL + "/Service/Complain/ReleaseEvaluate_Handled.aspx";
//��ȡ�ҵ����ۣ���������URL
var HTTP_GET_MYEVALUATE_HANDLED_URL = HTTP_IP_URL + "/Service/Complain/GetMyEvaluate_Handled.aspx";

//�ύ����URL
var HTTP_SUBMIT_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/SubmitProblem.aspx";
//��ȡ�ҵ������б�URL
var HTTP_GET_MYPROBLEM_LIST_URL = HTTP_IP_URL + "/Service/Problem/GetMyProblemList.aspx";
//��ȡ��������URL
var HTTP_GET_PROBLEM_DETAIL_URL = HTTP_IP_URL + "/Service/Problem/GetProblemDetail.aspx";
//ɾ���ҵ�����URL
var HTTP_DELETE_MYPROBLEM_URL = HTTP_IP_URL + "/Service/Problem/DeleteMyFeedback.aspx";
//��������(���⴦����)URL
var HTTP_RELEASE_EVALUATE_HANDLED_OF_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/ReleaseEvaluate_Handled.aspx";
//��ȡ�ҵ����ۣ����⴦������URL
var HTTP_GET_MYEVALUATE_HANDLED_OF_PROBLEM_URL = HTTP_IP_URL + "/Service/Problem/GetMyEvaluate_Handled_Of_Problem.aspx";

//��������URL
function GetURL_ReleseEvaluate() {
	return HTTP_RELEASE_EVALUATE_URL;
}
//��ȡ�������б�URL
function GetURL_GetToEvaluateList() {
    return HTTP_GET_TOEVALUATE_LIST_URL;
}
//��ȡ�ҵ������б�URL
function GetURL_GetMyEvaluateList() {
    return HTTP_GET_MYEVALUATE_LIST_URL;
}
//��ȡ��������URL
function GetURL_GetEvaluateDetail() {
    return HTTP_GET_EVALUATE_DETAIL_URL;
}
//�ύ����URL
function GetURL_SubmitFeedback() {
    return HTTP_SUBMIT_FEEDBACK_URL;
}
//��ȡ�ҵķ����б�URL
function GetURL_GetMyFeedbackList() {
    return HTTP_GET_MYFEEDBACK_LIST_URL;
}
//��ȡ��������URL
function GetURL_GetFeedbackDetail() {
    return HTTP_GET_FEEDBACK_DETAIL_URL;
}
//ɾ���ҵķ���URL
function GetURL_DeleteMyFeedback() {
    return HTTP_DELETE_MYFEEDBACK_URL;
}
//ɾ���ҵ�����URL
function GetURL_DeleteMyEvaluate() {
    return HTTP_DELETE_MYEVALUATE_URL;
}
//ɾ��������URL
function GetURL_DeleteToEvaluate() {
    return HTTP_DELETE_TOEVALUATE_URL;
}
//��ȡ��һ��������URL
function GetURL_GetLastEvaluated() {
    return HTTP_GET_LAST_EVALUATED_URL;
}
//��������(������)
function GetURL_ReleseEvaluate_Handled() {
    return HTTP_RELEASE_EVALUATE_HANDLED_URL;
}
//��ȡ�ҵ����ۣ���������URL
function GetURL_GetMyEvaluate_Handled() {
    return HTTP_GET_MYEVALUATE_HANDLED_URL;
}


//�ύ����URL
function GetURL_SubmitProblem() {
    return HTTP_SUBMIT_PROBLEM_URL;
}
//��ȡ�ҵ������б�URL
function GetURL_GetMyProblemList() {
    return HTTP_GET_MYPROBLEM_LIST_URL;
}
//��ȡ��������URL
function GetURL_GetProblemDetail() {
    return HTTP_GET_PROBLEM_DETAIL_URL;
}
//ɾ���ҵ�����URL
function GetURL_DeleteMyProblem() {
    return HTTP_DELETE_MYPROBLEM_URL;
}
//��������(���⴦����)URL
function GetURL_ReleseEvaluate_Handled_Of_Problem() {
    return HTTP_RELEASE_EVALUATE_HANDLED_OF_PROBLEM_URL;
}
//��ȡ�ҵ����ۣ����⴦������URL
function GetURL_GetMyEvaluate_Handled_Of_Problem() {
    return HTTP_GET_MYEVALUATE_HANDLED_OF_PROBLEM_URL;
}










