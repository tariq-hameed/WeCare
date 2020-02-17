const searchTerm = location.href.split("?")[1].split("=")[1];

// "/search.html?q=frans".split("?")
// ["/search.html", "q=frans"][1] => "q=frans"
// "q=frans".split("=") => ["q", "frans"]
// ["q", "frans"][1] => "frans"

const searchResultList = document.querySelector("ul.search-result");
const searchResultItemTemplate = document.querySelector("#search-result-item");

console.log(searchResultList, searchResultItemTemplate);

fetch(`https://localhost:44309/api/search?q=${searchTerm}`)
    .then(resp => resp.json())
    .then(patients => {

        patients.forEach(patient => {

            const clonedNode = searchResultItemTemplate.content.cloneNode(true);

            const anchor = clonedNode.querySelector("a");

            anchor.href = "/patient-details.html?id=" + patient.id;

            anchor.innerText = patient.firstName + " " + patient.lastName;

            searchResultList.appendChild(clonedNode);
        });

    });