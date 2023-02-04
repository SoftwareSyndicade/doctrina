
import { Navigate, Outlet, Route } from 'react-router-dom';
import LoginPage from '../../components/LoginPage/LoginPage';

const RouteGuard = () =>{
    const isAuth = false

    return (
        isAuth ? <Outlet/> : <Navigate to="/" />
    )
}

export default RouteGuard