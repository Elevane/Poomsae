import React from "react"
import { Layout } from "antd"
import Logo from "../Atoms/Logo"
import H1 from "../Atoms/Text/H1"

export interface LoginRegisterProps {
    child: React.ReactNode
    title: string
}
const LoginRegister: React.FC<LoginRegisterProps> = ({ child, title }) => {

    const LoginRegisterStyle: React.CSSProperties = {
        maxHeight: 400,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
    }

    return (
        <Layout className="app">
            <Layout style={LoginRegisterStyle}>
                <Logo src="jofa.png" name="logo_connexion_jofa" size="big" />
                <H1>{title}</H1>
                {child}
            </Layout>
        </Layout>
    )
}

export default LoginRegister