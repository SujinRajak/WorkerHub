function refreshGrid(gridId) {
    if ($(gridId)) {
        var datagrid = $(gridId).dxDataGrid('instance');
        if (datagrid) {
            datagrid.refresh();
        }
    }
}

const appendAlert = (message, type) => {
    const wrapper = document.createElement('div')
    var classItem = "";
    if (type == 'danger') {
        classItem = `<span class="icon-close-line-icon"></span>`
    } else {
        classItem = `<span class="icon-check-circle"></span>`
    }
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        /*`<div>${message}</div>`,*/
        ` <div class="alert-heading"> <div class="alert-notification">${classItem}</div><div class="title-alert"><strong> ${message} </strong></div></div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"><span class="icon-close"></span></button>',
        '</div>'
    ].join('')
    setTimeout(function () {
        wrapper.parentNode.removeChild(wrapper);
    }, 6000);
    document.getElementById('liveAlert').append(wrapper);
}

function formatDate(date) {
    const utcDate = new Date(date);
    const options = { month: '2-digit', day: '2-digit', year: 'numeric' };
    // Convert UTC to local time using toLocaleString
    const localDateStr = utcDate.toLocaleDateString(undefined, options);
    return localDateStr;
}

var myCustomStore = new DevExpress.data.CustomStore({
    key: "codeId",
    load: function (searchOptions) {
        searchOptions.skip = searchOptions.skip || 0;
        searchOptions.take = searchOptions.take || 100;
        searchOptions.searchOperation = searchOptions.searchOperation ||"contains";
        searchOptions.searchValue = searchOptions.searchValue||null;
        return LoadDiagnosisFromServer(searchOptions);
    },
    byKey: function (key) {
        return $.ajax({
            url: "/User/GetSelectedCityStates",
            method: "GET",
            data: { key: key },
            dataType: "json"
        });
    }
});

function LoadDiagnosisFromServer(searchOptions) {
    return $.ajax({
        url: "/User/GetCityStates",
        method: "POST",
        data: searchOptions,
        dataType: "json"
    });
}

var SelectboxDataSource = new DevExpress.data.DataSource({
    store: myCustomStore
});

function onDiagnosisDisplayExpr(e) {
    if (e != null && e != undefined && e.codeId > 0) {
        return e.codeValue;
    }
    else {
        return null;
    }
}