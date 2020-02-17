const formElement = document.querySelector("form");

const firstNameElement = formElement.querySelector("input[name=firstName");
const lastNameElement = formElement.querySelector("input[name=lastName");
const socialSecurityNumberElement = formElement.querySelector("input[name=socialSecurityNumber");

formElement.addEventListener("submit", event => {

    event.preventDefault();

    const data = {
        firstName: firstNameElement.value,
        lastName: lastNameElement.value,
        socialSecurityNumber: socialSecurityNumberElement.value
    };

    //console.log(data);

    fetch("https://localhost:44309/api/patients", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    }).then(resp => {
        location.href = "/list-patients.html";
    });
});