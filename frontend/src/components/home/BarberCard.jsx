import { barberService } from '../../services/barbers/barberService';

export default function BarberCard({barber}){

    let gender = barber.gender == 0 ? 'Male' : 'Female';
    let rating = barberService.calculateRating(barber.myAppointments);

    return(
        <>
            <div>
                <h2>Barber: {barber.username}</h2>
                <span>Gender: {gender}</span>
                <span>Rating: {rating}</span>
                <span>Appointments so far: {barber.myAppointments.length}</span>
            </div>
        </>
    )
}