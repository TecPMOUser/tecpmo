var globalServiceURL = 'http://localhost:53686/';
//var globalServiceURL = 'http://ctsc00507221001.cts.com:90/Tec-PMO-Services/';
//var globalServiceURL = 'http://tecpmo.cognizant.com/Tec-PMO-Services/';

function handleSuccess(res) {
    return res.data;
}

function handleError(error) {
    //return function () {
    //return { success: false, message: error,status:error.status };
    if (error.status === 401) {
        window.alert("you are not authorized person to access this page!!!");
        window.location.href = "#";        
    }
        return error.status;
    //};
}