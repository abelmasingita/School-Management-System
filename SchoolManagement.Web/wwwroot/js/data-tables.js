
'use strict';
//$(document).ready(function () {
//  $('#dataTable').DataTable({
//    "paging": true,
//    "ordering": true,
//    "info": true
//  });
//});

$('#dataTable').DataTable({
  "paging": true,
  "lengthChange": true,
  "searching": true,
  "ordering": true,
  "info": true,
  "autoWidth": false,
  "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
});
