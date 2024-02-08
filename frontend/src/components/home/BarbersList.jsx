import BarberCard from "./BarberCard"

export default function BarberList({data}){
    const barbers = data.barbers;
    const pageNumber = data.pageNumber;
    const pagesCount = data.pageCount;
    const content = barbers.map(b => <BarberCard key={b.id} barber={b}/>);
    
    return(
        <>
            <h1>barbers</h1>
            {content}
        </>
    )
}