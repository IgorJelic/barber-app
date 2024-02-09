import { useContext } from 'react'
import styles from './Common.module.css'
import { PaginationContext } from '../../contexts/PaginationContext'

export default function PaginationButton({
    pageNumber,
    activePage
}){
    const updatePageNumber = useContext(PaginationContext)

    return(
        <>
            <div 
                onClick={() => updatePageNumber(pageNumber)} 
                className={`${styles.paginationBtn} ${pageNumber === activePage ? styles.active : ''}`}>
                {pageNumber}
            </div>
        </>
    )
}