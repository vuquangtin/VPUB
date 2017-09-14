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
import com.nxp.nfclib.classic.ClassicFactory;
import com.nxp.nfclib.defaultimpl.KeyInfo;
import com.nxp.nfclib.desfire.DESFireFactory;
import com.nxp.nfclib.desfire.IDESFireEV1;
import com.nxp.nfclib.exceptions.CloneDetectedException;
import com.nxp.nfclib.interfaces.IKeyInfo;

import java.io.File;
import java.io.FileInputStream;
import java.security.Key;
import java.security.KeyStore;
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

    static
    {
        Security.insertProviderAt( new org.spongycastle.jce.provider.BouncyCastleProvider(), 1 );
    }

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

        switch( m_cardType )
        {
            case DESFireEV1:
                Log.d( TAG, "DESFireEV1 found" );
                m_objDESFireEV1 = DESFireFactory.getInstance()
                                                .getDESFire( m_libInstance.getCustomModules() );
                try
                {
                    m_objDESFireEV1.getReader().connect();
                    Log.d( TAG, "DESFireEV1 connected" );
                }
                catch( Throwable t )
                {
                    t.printStackTrace();
                }
                break;
        }
    }
}
