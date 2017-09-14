using System;

namespace ScanComponent.LibPlusTek {
    internal class LibPlusTekInstance : IDisposable {
        private static LibPlusTekInstance instance = null;
        private static readonly object lob = new object();
        private IntPtr handle;

        private LibPlusTekInstance() {
            handle = LibPlusTekWrapper.GetFunctionTable();

            if (handle == IntPtr.Zero) {
                throw new LibPlusTekException("Không tìm thấy Camera.dll");
            }
        }

        public static LibPlusTekInstance GetInstance() {
            if (instance == null) {
                lock (lob) {
                    if (instance == null) {
                        instance = new LibPlusTekInstance();
                    }
                }
            }
            return instance;
        }

        public IntPtr Handle {
            get { return handle; }
        }

        public void Dispose() {
            //LibPlusTekWrapper.FreeLibrary(handle);
        }
    }
}
