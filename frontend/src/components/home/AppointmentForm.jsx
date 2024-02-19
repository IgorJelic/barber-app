import { useEffect, useRef, useState } from 'react'
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
    const[selectedTime, setSelectedTime] = useState(null);

    const email = useRef(null);
    const phone = useRef(null);

    useEffect(() => {
        barberService.getBarberById(barberId)
            .then(b => {
                setBarber(b);
                setTakenAppointments(b.myAppointments);
            })
            .then(() => {
                setAvailableAppointments(generateShiftDateTimeArray(takenAppointments));
            }, []);
    }, [])

    const handleTimeSelect = (time) => {
        setSelectedTime(time);
    }

    const handleConfirmAppointment = () => {
        const appTime = new Date(selectedTime);
        appTime.setFullYear(new Date().getFullYear());

        // OBRADI PRELAZ U SLEDECU GODINU OBAVEZNO

        const appointment = {
            barberId: barberId,
            email: email.current.value,
            phone: phone.current.value,
            appointmentTime: appTime
        }

        console.log(appointment);
    }

    const table = 
        availableAppointments.map((ap, index) => 
            <div key={index} 
                 onClick={() => handleTimeSelect(formatDate(ap))} 
                 className={styles.date}>{formatDate(ap)}
            </div>)

    return(
        <>
            <div className={styles.appForm}>
                <div className={styles.leftForm}>

                    <h2 className={styles.appointmentTitle}>{barber.username}</h2>
                    <span><StarRating rating={barber.rating}/></span>
                    <span>Experience: {barber.appointmentsCount}
                                    {barber.appointmentsCount !== 1 ? ' clients' : ' client'}.</span>
                    <hr className={styles.line}/>
                    <span className={styles.availableHeader}>Available:</span>
                    <div className={styles.availableAppointments}>
                        {table}
                    </div>
                </div>

                <div className={styles.verticalLine}></div>

                <div className={styles.rightForm}>
                    <span className={styles.selectedTime}>{selectedTime?? 'Choose Time'}</span>
                    <input type="email" name="email" id="email" placeholder='email@gmail.com' ref={email}/>
                    <input type="tel" name="phone" id="phone" placeholder='Your Phone No.' ref={phone}/>
                    <button onClick={handleConfirmAppointment}>Confirm</button>
                </div>
            </div>
        </>
    )
}