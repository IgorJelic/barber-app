import styles from './Home.module.css';
import { formatRating } from '../../utils/formatUtils/ratingUtils';

export default function BarberCard({barber}){

    let gender = barber.gender == 0 ? 'Male' : 'Female';

    return(
        <>
            <div className={styles.card}>
                <h2 className={styles.title}>{barber.username}</h2>
                <div className={styles.info}>Gender: {gender}</div>
                <div className={styles.info}>Rating: <span className={styles.rating}>{formatRating(barber.rating)}</span></div>
                <div className={styles.info}>
                    Appointments so far: <span className={styles.count}>{barber.appointmentsCount}</span>
                </div>
                <hr className={styles.line}/>
                <button className={styles.btn}>Details</button>
            </div>
        </>
    )
}