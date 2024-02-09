import styles from './Common.module.css'
import PaginationButton from './PaginationButton';

export default function Pagination({
    activePage,
    pageCount,
}){
    const paginationNumbers = Array.from({length: pageCount}, (_, index) => index + 1);
    const paginationButtons = paginationNumbers.map(number => (
        <PaginationButton key={number} pageNumber={number} activePage={activePage}/>
    ))

    return(
        <div className={styles.pagination}>
            {paginationButtons}
        </div>
    )
}