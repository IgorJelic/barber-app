export const generateShiftDateTimeArray = (takenAppointments) => {
    const startTime = new Date();
    startTime.setHours(9, 0, 0, 0); // Set start time to 9:00

    const endTime = new Date();
    endTime.setHours(16, 30, 0, 0); // Set end time to 16:30

    const dateTimeArray = [];
    let currentTime = new Date(startTime);

    while (currentTime <= endTime) {
        if(!takenAppointments.some(app => new Date(app.appointmentTime).getTime() === currentTime.getTime())){
            dateTimeArray.push(new Date(currentTime));
        }
        // dateTimeArray.push(new Date(currentTime));
        currentTime.setMinutes(currentTime.getMinutes() + 30); // Increment by 30 minutes
    }

    return dateTimeArray;
}