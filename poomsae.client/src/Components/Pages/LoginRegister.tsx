import React from "react"
import { Layout } from "antd"
import Logo from "../Atoms/Logo"
import H1 from "../Atoms/Text/H1"
import AppLayout from "../Fragments/Generic/AppLayout"

export interface LoginRegisterProps {
    child: React.ReactNode
    title: string
}
const LoginRegister: React.FC<LoginRegisterProps> = ({ child, title }) => {

    const LoginRegisterStyle: React.CSSProperties = {
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
    }

    return (
        <AppLayout>
            <Layout style={LoginRegisterStyle}>
                <Logo name="poomsae_connexion_logo" size="big" />
                <H1>{title}</H1>
                {child}
            </Layout>
        </AppLayout>
    )
}

export default LoginRegister