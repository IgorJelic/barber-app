import { useContext } from 'react'
import styles from './Common.module.css'
import { FilterContext } from '../../contexts/FilterContext'

export default function PaginationButton({
    pageNumber,
    activePage
}){
    const updatePageNumber = useContext(FilterContext);

    return(
        <>
            <div 
                onClick={() => updatePageNumber(prevFilter => ({
                    ...prevFilter,
                    pageNumber: pageNumber
                }))} 
                className={`${styles.paginationBtn} ${pageNumber === activePage ? styles.active : ''}`}>
                {pageNumber}
            </div>
        </>
    )
}