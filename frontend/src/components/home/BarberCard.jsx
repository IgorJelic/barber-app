import styles from './Home.module.css';
import { formatRating } from '../../utils/formatUtils/ratingUtils';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faScissors } from '@fortawesome/free-solid-svg-icons';
import { useEffect, useState } from 'react';
import AppointmentForm from './AppointmentForm';
import Modal from '../common/Modal';

export default function BarberCard({barber}){
    const [barberId, setBarberId] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);

    const openModal = () => {
        setIsModalOpen(true);
    }
    
    const closeModal = () => {
        setIsModalOpen(false);
    }

    let gender = barber.gender == 0 ? 'Male' : 'Female';
    
    useEffect(() => {
        setBarberId(barber.id);
    },[]);

    return(
        <>
            <div className={styles.card}>
                <FontAwesomeIcon icon={faScissors} className={styles.cardLogo}/>
                <FontAwesomeIcon onClick={openModal} icon={faScissors} className={styles.cardBtn}/>
                <h2 className={styles.title}>{barber.username}</h2>
                <hr className={styles.line}/>
                <div className={styles.info}>Gender: {gender}</div>
                <div className={styles.info}>Rank: <span className={styles.rating}>{formatRating(barber.rating)}</span></div>
                <div className={styles.info}>
                    Appointments so far: <span className={styles.count}>{barber.appointmentsCount}</span>
                </div>
                {/* <button className={styles.btn}>Details</button> */}
            </div>
            <Modal isModalOpen={isModalOpen} onClose={closeModal}>
                <AppointmentForm barberId={barberId} />
            </Modal>
        </>
    )
}