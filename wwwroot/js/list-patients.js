const patientTableBody = document.querySelector("table.patients tbody");
const patientTableRowTemplate = document.querySelector("#patient-row");

fetch("https://localhost:44309/api/patients")
    .then(resp => resp.json())
    .then(patients => {

        patients.forEach(patient => {

            let trClone = patientTableRowTemplate.content.cloneNode(true);

            let idElement = trClone.querySelector(".id");
            let firstNameAnchorElement = trClone.querySelector(".first-name a");
            let lastNameElement = trClone.querySelector(".last-name");
            let socialSecurityNumberElement = trClone.querySelector(".social-security-number");

            idElement.innerText = patient.id;
            firstNameAnchorElement.innerText = patient.firstName;
            firstNameAnchorElement.href = `/patient-details.html?id=${patient.id}`;
            lastNameElement.innerText = patient.lastName;
            socialSecurityNumberElement.innerText = patient.socialSecurityNumber;

            const trElement = trClone.querySelector("tr");

            trElement.dataset.patientId = patient.id;

            patientTableBody.appendChild(trClone);
        });

        var deleteButtons = document.querySelectorAll("table.patients button");

        deleteButtons.forEach(function (button) {
            button.addEventListener("click", handleDeleteClick);
        });


        function handleDeleteClick() {
            const tr = this.parentElement.parentElement;

            if (!confirm("Are you sure you want to delete this patient?")) {
                return;
            }

            fetch("https://localhost:44309/api/patients/" + tr.dataset.patientId, {
                method: "DELETE"
            })
                .then(resp => {
                    if (resp.ok) {
                        tr.remove();
                    }
                });
        }
    });

//function handleDeleteClick(event) {

//}

// pending
// resolved
// rejected

