/**
 * Account Settings - Account
 */

'use strict';

document.addEventListener("DOMContentLoaded", function () {
  const roleSelect = document.getElementById("roleSelect");
  const roleSpecificFields = document.getElementById("roleSpecificFields");
  roleSelect.addEventListener("change", function () {
    loadRoleSpecificFields(roleSelect.value);
  });

  function loadRoleSpecificFields(role) {
    if (role) {
      fetch(`/UserManagement/GetRoleSpecificFields?role=${role}`)
        .then(response => response.text())
        .then(html => {
          roleSpecificFields.innerHTML = html;
        })
        .catch(error => console.error('Error loading role-specific fields:', error));
    } else {
      roleSpecificFields.innerHTML = '';
    }
  }
});
