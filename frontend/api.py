"""API client for backend communication."""

import requests


class SpacegameAPI:
    """
    Centralized API client for all backend communication.

    Handles authentication headers and provides consistent error handling.
    """

    def __init__(self, base_url: str):
        self.base_url = base_url
        self.token = None

    def get_headers(self) -> dict:
        """Get authorization headers for API requests."""
        if self.token:
            return {"Authorization": f"Token {self.token}"}
        return {}

    def login(self, username: str) -> dict | None:
        """
        Authenticate user and obtain token.

        Returns:
            Dict with 'token' and 'username' on success, None on failure.
        """
        try:
            response = requests.post(
                f"{self.base_url}login/",
                json={"username": username}
            )
            if response.status_code == 200:
                data = response.json()
                self.token = data.get("token")
                return data
            return None
        except requests.exceptions.RequestException:
            return None
