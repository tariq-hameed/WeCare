const h1 = document.querySelector(".patient-fullname");

// TODO:  Plocka ut värdet på "id" från query string och använd det 
// i URL:en nedan

const patientId = location.href.split("?")[1].split("=")[1];

fetch("https://localhost:44309/api/patients/" + patientId)
    .then(resp => resp.json())
    .then(patient => {

        let fullName = `${patient.firstName} ${patient.lastName}`;  // string template

        h1.innerText = fullName;

        //var synth = window.speechSynthesis;
        //synth.speak(new SpeechSynthesisUtterance("Mustafa, where are you going? We have more lessons!"));


        // TODO: välj ur h1 med class "patient-fullname" och sätt 
        // värdet till det av fullName



        //patients.forEach(patient => {

        //    let trClone = patientTableRowTemplate.content.cloneNode(true);

        //    let idElement = trClone.querySelector(".id");
        //    let firstNameElement = trClone.querySelector(".first-name");
        //    let lastNameElement = trClone.querySelector(".last-name");
        //    let socialSecurityNumberElement = trClone.querySelector(".social-security-number");

        //    idElement.innerText = patient.id;
        //    firstNameElement.innerText = patient.firstName;
        //    lastNameElement.innerText = patient.lastName;
        //    socialSecurityNumberElement.innerText = patient.socialSecurityNumber;

        //    patientTableBody.appendChild(trClone);
        //});
    });

const journalEntriesTableBody = document.querySelector("table.journal-entries tbody");
const journalEntriesRowTemplate = document.querySelector("#journal-entry-row");

// HTTP GET https://localhost:44309/api/patients/1/journal
fetch("https://localhost:44309/api/patients/" + patientId + "/journal")
    .then(resp => resp.json())
    .then(journal => {

        journal.entries.forEach(journalEntry => {

            AddJournalEntryRow(journalEntry);


        });
    });

function AddJournalEntryRow(journalEntry) {

    let trClone = journalEntriesRowTemplate.content.cloneNode(true);

    let idElement = trClone.querySelector(".id");
    let dateElement = trClone.querySelector(".date");
    let entryElement = trClone.querySelector(".entry");

    idElement.innerText = journalEntry.id;
    dateElement.innerText = journalEntry.date;
    entryElement.innerText = journalEntry.entry;

    journalEntriesTableBody.appendChild(trClone);
}

const formElement = document.querySelector("form"),
    dateInputElement = document.querySelector("input[name=date]"),
    entryTextareaElement = document.querySelector("textarea[name=entry]");

formElement.addEventListener("submit", function (event) {

    event.preventDefault();

    const date = dateInputElement.value;
    const entry = entryTextareaElement.value;

    const data = {
        date: date,
        entry: entry
    };

    // HTTP POST https://localhost:44309/api/patients/1/journal/entries
    fetch(`https://localhost:44309/api/patients/${patientId}/journal/entries`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(journalEntry => {

            AddJournalEntryRow(journalEntry);
        });

    // Do POST request to server
    // If status code == 201, add data to table (create tr and add to table)
});

