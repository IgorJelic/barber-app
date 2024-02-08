import {Header} from './Header.jsx';
import {Footer} from './Header.jsx';
 
export default function Layout({children}) {
    return (
        <>
            <Header />
            {children}
            <Footer />
        </>
    )
        
}