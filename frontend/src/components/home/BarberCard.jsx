import styles from './Home.module.css';
import { formatRating } from '../../utils/formatUtils/ratingUtils';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faScissors } from '@fortawesome/free-solid-svg-icons';

export default function BarberCard({barber}){

    let gender = barber.gender == 0 ? 'Male' : 'Female';

    return(
        <>
            <div className={styles.card}>
                <FontAwesomeIcon icon={faScissors} className={styles.cardLogo}/>
                <FontAwesomeIcon icon={faScissors} className={styles.cardBtn}/>
                <h2 className={styles.title}>{barber.username}</h2>
                <hr className={styles.line}/>
                <div className={styles.info}>Gender: {gender}</div>
                <div className={styles.info}>Rank: <span className={styles.rating}>{formatRating(barber.rating)}</span></div>
                <div className={styles.info}>
                    Appointments so far: <span className={styles.count}>{barber.appointmentsCount}</span>
                </div>
                {/* <button className={styles.btn}>Details</button> */}
            </div>
        </>
    )
}