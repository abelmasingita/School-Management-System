
'use strict';
document.addEventListener('DOMContentLoaded', function () {
  var calendarEl = document.getElementById('calendar');

  var calendar = new FullCalendar.Calendar(calendarEl, {
    initialView: 'timeGridWeek',
    selectable: true,
    selectMirror: true,
    dayMaxEvents: true,
    weekends: true,
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    slotMinTime: "06:00:00",
    slotMaxTime: "24:00:00",
    timeZone: 'Africa/Johannesburg',
    events: function (fetchInfo, successCallback, failureCallback) {
      $.ajax({
        url: 'GetEvents', 
        type: 'Get',
        dataType: 'json',
        success: function (data) {
          var events = [];
          data.forEach(function (item) {
            events.push({
              id: item.id,
              title: item.title,
              start: item.start,
              end: item.end,
              allDay: item.allDay
            });
          });
          successCallback(events);

        },
        error: function () {
          alert('Failed to fetch events.');
          failureCallback();
        }
      });
    },

    eventClick: function (info) {
      populateOffcanvas(info.event)

      var canvasBtn = document.getElementById('canvasBtn');
      canvasBtn.click();
    },
    select: function (info) {
      promptEvent(info);
    }


  });

  calendar.render();

  function promptEvent(info) {
    var title = prompt('Please enter a new event title:');
    if (title) {
      calendar.addEvent({
        title: title,
        start: info.startStr,
        end: info.endStr,
        allDay: info.allDay 
      });
      saveEvent(title, info.startStr, info.endStr); 
    }
  }
  function saveEvent(title, start, end) {
    $.ajax({
      url: 'AddEvent',
      type: 'POST',
      data: { title: title, start: start, end: end },
      success: function () {
        alert('Event added successfully!');
        calendar.refetchEvents();
        window.location.reload()
      },
      error: function () {
        alert('Failed to add event.');
      }
    });
  }

  function populateOffcanvas(event) {
    document.getElementById('id').value = event.id;
    document.getElementById('title').value = event.title;
    document.getElementById('start').value = event.startStr;
    document.getElementById('end').value = event.endStr;
    document.getElementById('allDay').checked = event.allDay;
  }
});

