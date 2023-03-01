const uri = '/Assiment';
let assiments = [];

function getAssiments() {
    fetch(uri)
        .then(response => response.json())
        .then(data =>  { _displayAssiments(data)})
        .catch(error => console.error('Unable to get assiments.', error));
}

function addAssiment() {
    const addDescriptionTextbox = document.getElementById('add-assiment');

    const assiment = {
        Done: false,
        Description: addDescriptionTextbox.value.trim()
    };
    fetch(uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(assiment)
        })
        .then(response => response.json())
        .then(() => {
            getAssiments();
            addDescriptionTextbox.value = '';
        })
        .catch(error => console.error('Unable to add assiment.', error));
    }

function deleteAssiment(id) {
    fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
        .then(() => getAssiments())
        .catch(error => console.error('Unable to delete assiment.', error));
}

function displayEditForm(id) {
    const assiment = assiments.find(a => a.id === id);
    console.log(assiment.done);
    document.getElementById('edit-description').value = assiment.description;
    document.getElementById('edit-id').value = assiment.id;
    document.getElementById('edit-done').checked = assiment.done;
    document.getElementById('editForm').style.display = 'block';
}

function updateAssiment() {
    const assimentId = document.getElementById('edit-id').value;
    const assiment = {
        Id: parseInt(assimentId, 10),
        Done: document.getElementById('edit-done').checked,
        Description: document.getElementById('edit-description').value.trim()
    };
    console.log(assiment)
    fetch(`${uri}/${assimentId}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(assiment)
        })
        .then(() => getAssiments())
        .catch(error => console.error('Unable to update assiment.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(assimentCount) {
    const name = (assimentCount === 1) ? 'assiment' : 'assiments';

    document.getElementById('counter').innerText = `${assimentCount} ${name}`;
}

function _displayAssiments(data) {
    const tBody = document.getElementById('assiments');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(assiment => {
        let isDoneCheckbox = document.createElement('input');
        isDoneCheckbox.type = 'checkbox';
        isDoneCheckbox.disabled = true;
        isDoneCheckbox.checked = assiment.done;
        console.log(assiment);

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${assiment.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteAssiment(${assiment.d})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isDoneCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(assiment.description);
        console.log(assiment.description);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    assiments = data;
}