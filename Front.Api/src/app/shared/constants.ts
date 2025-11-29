export const Constants = {
  Title: {
    VALIDATE: 'Validación',
    ERROR: 'Error',
    UNAUTHORIZED: 'No autorizado',
    ACCESS_DENIED: 'Acceso denegado',
    SERVER_ERROR: 'Error del servidor',
  },
  Session: {
    TOKEN: 'token',
    EMAIL: 'email',
  },
  Messages: {
    DEFAULT_ERROR: 'Ocurrió un error. Intenta nuevamente más tarde.',
    SESSION_EXPIRED:
      'Tu sesión ha expirado. Por favor inicia sesión nuevamente.',
    ACCESS_DENIED: 'No tienes permisos para realizar esta acción.',
  },
  Buttons: {
    CONFIRM_BUTTON: 'ACEPTAR',
    DELETE_OK: 'Eliminar',
    DELETE_CANCEL: 'Cancelar',
  },
  Delete: {
    DELETE_TITLE: 'Confirmar eliminación',
    DELETE_TEXT:
      '¿Estás seguro que deseas eliminarlo? Esta acción no se puede deshacer.',
  },
  Api: {
    DEFAULT_TIMEOUT_MS: 30000,
  },
};

export type TConstants = typeof Constants;
