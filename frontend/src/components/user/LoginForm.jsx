import { useRef } from 'react'
import styles from './User.module.css'
import commonStyles from '../common/Common.module.css'
import { userService } from '../../services/users/userService';

export default function LoginForm(){
    const username = useRef(null);
    const password = useRef(null);
    const remember = useRef(null);

    const handleButton = () => {
        // validate

        const user = {
            username: username.current.value,
            password: username.current.value
        }
        userService.login(user)
    }

    return (
        <>
            <div className={styles.loginForm}>
                <div className={commonStyles.inputGroup}>
                    <label  htmlFor='username'>Username: </label>
                    <input className={commonStyles.input} type='text' id='username' placeholder='Username' ref={username}/>
                </div>
                <div className={commonStyles.inputGroup}>
                    <label htmlFor='password'>Password: </label>
                    <input className={commonStyles.input} type='password' id='password' placeholder='****' ref={password}/>
                </div>
                <hr className={commonStyles.line}/>
                <div className={styles.rememberGroup}>
                    <label htmlFor='remember'>Remember me </label>
                    <input className={commonStyles.input} type='checkbox' id='remember' ref={remember}/>
                </div>
                <button className={commonStyles.button} onClick={handleButton}>Login</button>
            </div>
        </>
    )
}