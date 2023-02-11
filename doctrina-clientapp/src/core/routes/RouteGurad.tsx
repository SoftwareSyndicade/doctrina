
import { ExtractAtomValue, useAtom, useAtomValue } from 'jotai';
import { Navigate, Outlet, Route } from 'react-router-dom';
import { userAtom } from '../AtomsConfig';

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