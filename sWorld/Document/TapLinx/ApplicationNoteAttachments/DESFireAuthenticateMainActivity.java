package com.nxp.taplinx;

import android.annotation.TargetApi;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;

import com.nxp.nfclib.CardType;
import com.nxp.nfclib.KeyType;
import com.nxp.nfclib.NxpNfcLib;
import com.nxp.nfclib.defaultimpl.KeyData;
import com.nxp.nfclib.desfire.DESFireFactory;
import com.nxp.nfclib.desfire.IDESFireEV1;

import java.security.Key;
import java.security.Security;

import javax.crypto.SecretKey;
import javax.crypto.spec.SecretKeySpec;

public class MainActivity extends AppCompatActivity
{
    public static final String TAG = MainActivity.class.getSimpleName();

    // The package key you will get from the registration server
    private static String m_strPackageKey = "00112233445566778899aabbccddeeff";

    // The TapLinX library instance
    private NxpNfcLib   m_libInstance   = null;

    private IDESFireEV1 m_objDESFireEV1 = null;
    private CardType    m_cardType      = CardType.UnknownCard;

    public static final byte[] DEFAULT_KEY_2KTDES =
    {                                                 // Default 2kTDES key
        (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00,
        (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00,
        (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00,
        (byte)0x00, (byte)0x00, (byte)0x00
    };





    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        initializeLibrary();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    /**
     * Initialize the library and register to this activity.
     */
    @TargetApi(19)
    private void initializeLibrary()
    {
        m_libInstance = NxpNfcLib.getInstance();
        m_libInstance.registerActivity(this, m_strPackageKey);
    }

    ///////////////////////////////////////////////////////////////////////////

    @Override
    protected void onResume()
    {
        m_libInstance.startForeGroundDispatch();
        super.onResume();
    }

    ///////////////////////////////////////////////////////////////////////////

    @Override
    protected void onPause()
    {
        m_libInstance.stopForeGroundDispatch();
        super.onPause();
    }

    ///////////////////////////////////////////////////////////////////////////

    /**
     * @param intent NFC intent from the android framework.
     * @see android.app.Activity#onNewIntent(android.content.Intent)
     */
    @Override
    public void onNewIntent( final Intent intent )
    {
        Log.d( TAG, "onNewIntent" );
        cardLogic( intent );
        super.onNewIntent( intent );
    }

    private void cardLogic( final Intent intent )
    {
        m_cardType = m_libInstance.getCardType( intent );
        if( CardType.DESFireEV1 == m_cardType )
        {
             Log.d( TAG, "DESFireEV1 found" );
             m_objDESFireEV1 = DESFireFactory.getInstance()
                                             .getDESFire( m_libInstance.getCustomModules() );
             try
             {
                 m_objDESFireEV1.getReader().connect();
                                         // Timeout to prevent exceptions in authenticate
                 m_objDESFireEV1.getReader().setTimeout( 2000 );
                                         // Select root app
                 m_objDESFireEV1.selectApplication( 0 );
                 Log.d( TAG, "AID 000000 selected" );
                                         // DEFAULT_KEY_2KTDES is a byte array of 24 zero bytes
                 Key key = new SecretKeySpec( DEFAULT_KEY_2KTDES, "DESede" );
                 KeyData keyData = new KeyData();
                 keyData.setKey( key );
                                         // Authenticate to PICC Master Key
                 m_objDESFireEV1.authenticate( 0, IDESFireEV1.AuthType.Native,
                                                  KeyType.TWO_KEY_THREEDES, keyData );
                 Log.d( TAG, "DESFireEV1 authenticated" );
             }
             catch( Throwable t )
             {
                 t.printStackTrace();
             }
        }
    }
}
