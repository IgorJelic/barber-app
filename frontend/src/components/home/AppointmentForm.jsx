import { useEffect, useState } from 'react'
import styles from './Home.module.css'
import {barberService} from '../../services/barbers/barberService';
import { generateShiftDateTimeArray } from '../../utils/formatUtils/shiftDateTimeGenerator';
import { formatDate } from '../../utils/formatUtils/dateTimeFormatUtils';
import StarRating from '../common/StarRating';

export default function AppointmentForm({
    barberId
}){
    const[barber, setBarber] = useState({});
    const[takenAppointments, setTakenAppointments] = useState([]);
    const[availableAppointments, setAvailableAppointments] = useState([]);

    useEffect(() => {
        barberService.getBarberById(barberId)
            .then(b => {
                setBarber(b);
                setTakenAppointments(b.myAppointments);
            })
            .then(() => {
                setAvailableAppointments(generateShiftDateTimeArray(takenAppointments));
            });
    },[])

    const table = 
        availableAppointments.map((ap, index) => <div key={index} className={styles.date}>{formatDate(ap)}</div>)

    return(
        <>
            <div className={styles.appForm}>
                <h2>{barber.username}</h2>
                <span><StarRating rating={barber.rating}/></span>
                <span>Experience: {barber.appointmentsCount}
                                  {barber.appointmentsCount !== 1 ? ' clients' : ' client'}.</span>
                <hr className={styles.line}/>
                <span className={styles.availableHeader}>Available:</span>
                <div className={styles.availableAppointments}>
                    {table}
                </div>
            </div>
        </>
    )
}