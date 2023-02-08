
import { ExtractAtomValue, useAtomValue } from 'jotai';
import { Navigate, Outlet, Route } from 'react-router-dom';
import LoginPage from '../../components/LoginPage/LoginPage';
import { userAtom } from '../AtomsConfig';
import useAuth from '../auth/useAuth';

const RouteGuard = () =>{
    const user = useAtomValue(userAtom)
    const isAuthenticated = test(user)

    function test(user: ExtractAtomValue<typeof userAtom>){
        return user.IS_AUTHENTICATED
    }

    return (
        isAuthenticated ? <Outlet/> : <Navigate to="/" />
    )
}

export default RouteGuard