import { useState } from 'react';
import styles from './Common.module.css'

export default function Modal({
    isModalOpen,
    onClose,
    children
}){
    if (!isModalOpen) return null;
    
    return (
        <>
            <div onClick={onClose} className={styles.modalOverlay}>
                <div onClick={(e) => e.stopPropagation()} className={styles.modal}>
                    {children}
                </div>
            </div>
        </>
    )
}