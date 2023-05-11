var elements=document.querySelectorAll('[data-val="true"]')
for(let element of elements){
    element.addEventListener("keyup", function (e) {
        switch(e.target.id){
            case 'Email':
                emailValidator(e.target.value)
                break;
            case 'Password':                
                passwordValidator(e.target.value)
                break;
            case 'FirstName':
                firstnameValidator(e.target.value)
                break;
            case 'LastName':
                lastnameValidator(e.target.value)
                break;

        }
    })
}
function passwordValidator(value){
    const passwordRegEx=/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    if (passwordRegEx.test(value)){
        document.querySelector('[data-valmsg-for="Password"]').innerHTML=""
    }else{
        document.querySelector('[data-valmsg-for="Password"]').innerHTML ="Password is invaild.Password must contain at least one lowercase, one uppecase, one digit and one special character. The length should be at least 8 character "
    }
    return passwordRegEx.test(value);
}

function emailValidator(value){
    const emailRegEx=/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$/;
    if (emailRegEx.test(value)){
        document.querySelector('[data-valmsg-for="Email"]').innerHTML=""
    }else{
        document.querySelector('[data-valmsg-for="Email"]').innerHTML ="Email is invaild"
    }
    return emailRegEx.test(value);
}

function firstnameValidator(value) {
    const nameRegEx = /^[a-zA-Z]{2,30}$/
    if (nameRegEx.test(value)) {
        document.querySelector('[data-valmsg-for="FirstName"]').innerHTML = ""
    } else {
        document.querySelector('[data-valmsg-for="FirstName"]').innerHTML = "Input is invaild.FirstName's length should between 2 to 30 characters and can not include special character "
    }
    return nameRegEx.test(value);
}
function lastnameValidator(value) {
    const nameRegEx = /^[a-zA-Z]{2,30}$/
    if (nameRegEx.test(value)) {
        document.querySelector('[data-valmsg-for="LastName"]').innerHTML = ""
    } else {
        document.querySelector('[data-valmsg-for="LastName"]').innerHTML = "Input is invaild.LastName's length should between 2 to 30 characters and can not include special character "
    }
    return nameRegEx.test(value);
}
