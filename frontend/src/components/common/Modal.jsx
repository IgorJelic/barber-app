import styles from './Common.module.css'

export default function Modal({
    isModalOpen,
    onClose,
    children
}){
    if (!isModalOpen) return null;
    
    return (
        <>
            <div className={styles.modalOverlay}>
                <div className={styles.modal}>
                    <button onClick={onClose} className={styles.modalCloseBtn}>
                        Close
                    </button>
                    {children}
                </div>
            </div>
        </>
    )
}