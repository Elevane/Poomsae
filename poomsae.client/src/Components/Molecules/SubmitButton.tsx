import { LoadingOutlined } from "@ant-design/icons"
import { Button, Form } from "antd"
import React from "react"

export interface SubmitButtonProps {
    loading: boolean
    text: string
    style?: React.CSSProperties
    children?: React.ReactNode
    disabled?: boolean
    onClick?: () => void
}

const SubmitButton: React.FC<SubmitButtonProps> = ({ loading, text, children, style, onClick, disabled = false }) => {
    return (<Form.Item >
        <Button
            onClick={onClick}
            disabled={loading || disabled}
            style={{
                ...style, width: "300px", margin: "2vh", height: "40px", borderRadius: 0, fontSize: "16px"
            }}
            type="primary"
            htmlType="submit">
            {loading && <LoadingOutlined />}{text}
        </Button>
        {children}
    </Form.Item>
    )
}

export default SubmitButton