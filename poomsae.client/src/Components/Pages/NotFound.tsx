import { Result } from "antd"
import Link from "antd/es/typography/Link"
import React from "react"
import { useNavigate } from "react-router-dom"

const NotFound: React.FC = () => {
    const navigate = useNavigate()

    const goHome = () => {
        navigate('/login');
    };


    return (<Result
        status="404"
        title="404"
        subTitle="Sorry the page you're looking for doesn't exist"
        extra={<Link onClick={goHome}>Go back to safety</Link>}
    />)
}

export default NotFound