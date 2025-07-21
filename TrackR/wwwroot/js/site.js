$(document).ready(function () {
    const table = $('#applications').DataTable({

    });

    $('#customSearch').on('keyup', function () {
      table.search(this.value).draw();
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const editLinks = document.querySelectorAll('.edit-link');
    editLinks.forEach(link => {
        link.addEventListener('click', () => {
            document.getElementById('edit-id').value = link.dataset.id;
            document.getElementById('edit-name').value = link.dataset.name;
            document.getElementById('edit-position').value = link.dataset.position;
            document.getElementById('edit-location').value = link.dataset.location;
            document.getElementById('edit-date').value = link.dataset.applicationdate;
            document.getElementById('edit-status').value = link.dataset.status;
        });
    });

    const deleteLinks = document.querySelectorAll('.delete-link');
    deleteLinks.forEach(link => {
        link.addEventListener('click', () => {
            document.getElementById('delete-id').value = link.dataset.id;
        });
    });
});
