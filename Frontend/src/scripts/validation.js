function validateNotEmptyStringWithLength(firstName, length, errorMessage) {
    if (firstName.trim() === "" || firstName.length > length) {
        console.error(errorMessage ? errorMessage : `invalid value`);
        return false;
    }
    return true;
}
// function validateLastName(lastName, length) {
//     if (lastName.trim() === "" || lastName.length > length) {
//         console.error(`Last Name cannot be empty or longer than ${length} letters`);
//         return false;
//     }
//     return true;
// }
function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (email.trim() === "" || !emailRegex.test(email)) {
        console.error("Invalid email address");
        return false;
    }
    return true;
}
function validatePhoneNumber(phoneNumber) {
    const phoneRegex = /\(?\d{3}\)?-? *\d{3}-? *-?\d{4}/;
    if (phoneNumber.trim() !== "" && phoneRegex.test(phoneNumber)) {
        return true;
    }
    console.error('Invalid phone number');
    return false;
}
function isValidId(id){
    const regEx = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/;
    return regEx.test(id);
}