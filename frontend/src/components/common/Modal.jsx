import { useState } from 'react';
import styles from './Common.module.css'

export default function Modal({
    isModalOpen,
    onClose,
    children
}){
    if (!isModalOpen) return null;

    const handleModalHover = (event) => {
        event.stopPropagation();
    };
    
    return (
        <>
            <div onClick={onClose} className={styles.modalOverlay}>
                <div onMouseOver={handleModalHover} className={styles.modal}>
                    {children}
                </div>
            </div>
        </>
    )
}