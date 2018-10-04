const apiUrl = "http://localhost:49998/api/tasks";

window.onload = function () {
    loadTasks();
};

function loadTasks() {
    fetch(apiUrl)
        .then(function (response) {
            return response.json();
        })
        .then(function (array) {
            tableBody.innerHTML = "";
            array.forEach(addTaskToTable);
        });
}
function addTask() {
    event.preventDefault();
    fetch(apiUrl,
        {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(taskTitle.value)
        })
        .then(() => {
            loadTasks();
        });
}
function updateTask() {
    fetch(`${apiUrl}/${this.id}`,
        {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(!this.done)
        })
        .then(() => {
            loadTasks();
        });
}
function addTaskToTable(task) {
    let row = document.createElement("tr");
    let titleCell = document.createElement("td");
    let doneCell = document.createElement("td");
    let doneCheckbox = document.createElement("input");

    titleCell.innerText = task.title;
    doneCheckbox.type = "checkbox";
    if (task.done) {
        doneCheckbox.setAttribute("checked", task.done);

    }
    doneCheckbox.addEventListener("change", updateTask.bind(task));

    doneCell.appendChild(doneCheckbox);
    row.appendChild(titleCell);
    row.appendChild(doneCell);
    tableBody.appendChild(row);
}