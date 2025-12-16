from rest_framework.decorators import api_view, permission_classes
from rest_framework.permissions import IsAuthenticated
from rest_framework.response import Response
from rest_framework import status
from django.contrib.auth.models import User
from rest_framework.authtoken.models import Token


@api_view(['POST'])
def login(request):
    """
    Logs in a user or creates a new one if the username doesn't exist.

    Parameters:
    - username (str): The username to login with.

    Returns:
    - token (str): The authentication token.
    - username (str): The username.
    """
    username = request.data.get('username')
    if not username:
        return Response({'error': 'Username is required'}, status=status.HTTP_400_BAD_REQUEST)

    user, created = User.objects.get_or_create(username=username)
    token, _ = Token.objects.get_or_create(user=user)

    return Response({'token': token.key, 'username': user.username})
