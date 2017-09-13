
/*

读取数据
刘波
于2017年6月7日
*/

$(function () {
    $.getotherclientdata();
})
var clientareaItem = [];//得到地区列表
var shoolarealist = [];//校区
var bk_deptlist = [];//系
var bk_majorlist = [];//专业
var bk_majordetaillist = [];//专业方向
var bk_classinfolist = [];//班级信息

var bk_dormbuildinglist = [];//宿舍楼
var bk_dormunitlist = [];//单元
var bk_dormfloorslist = [];//楼层
var bk_dormlist = [];//房间

var bk_sturegflowlist = [];//当前用户可以操作的流程

$.getotherclientdata = function () {
    $.ajax({
        url: contentPath + "/OtherClientData/GetOtherClientDataJson",
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            clientareaItem = data.areaData;//地区列表 
            shoolarealist = data.schoolData;//校区列表
            bk_deptlist = data.deptData;//系列表
            bk_majorlist = data.majorData;//专业表
            bk_majordetaillist = data.majordetailData;//专业方向
            bk_classinfolist = data.classData;//班级

            bk_dormbuildinglist = data.buildingData;//宿舍楼
            bk_dormunitlist = data.unitData;//单元
            bk_dormfloorslist = data.floorsData;//楼层
            bk_dormlist = data.dormData;//房间

            bk_sturegflowlist = data.flowData;//当前用户可以操作的报到流程
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            dialogMsg(errorThrown, -1);
        }
    });
}