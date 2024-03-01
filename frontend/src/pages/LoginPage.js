import styles from '../components/common/Common.module.css';
import LoginForm from "../components/user/LoginForm";

export default function LoginPage(){

    return (
        <>
            <div className={styles.flexWrapperColumn}>
                <LoginForm/>
            </div>
        </>
    )
}